using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data.Entity.Infrastructure;
using DAL;
using DAL.Repositories;

namespace BLL.Services
{
    public class AgentService
    {
        private readonly AgentRepository _agentRepo;

        public AgentService()
        {
            _agentRepo = new AgentRepository();
        }

        public List<Agent> GetAllAgents()
        {
            return _agentRepo.GetAll();
        }

        public void AddAgent(Agent agent)
        {
            ValidateAgent(agent);

            if (_agentRepo.IsPhoneExists(agent.Phone.Trim()))
            {
                throw new InvalidOperationException($"Phone number '{agent.Phone}' belongs to another agent.");
            }

            try
            {
                agent.AgentName = agent.AgentName.Trim();
                agent.Address = agent.Address.Trim();
                agent.Phone = agent.Phone.Trim();
                _agentRepo.Add(agent);
            }
            catch (DbUpdateException ex) when (IsUniqueConstraintViolation(ex))
            {
                throw new InvalidOperationException("Phone number of the agent is already exists in the system.");
            }
        }

        public void UpdateAgent(Agent agent)
        {
            if (agent == null || agent.AgentID <= 0)
                throw new ArgumentException("Agent to update is invalid.");

            ValidateAgent(agent);

            if (_agentRepo.IsPhoneExists(agent.Phone.Trim(), excludeAgentId: agent.AgentID))
            {
                throw new InvalidOperationException($"Phone number '{agent.Phone}' belongs to another agent.");
            }

            agent.AgentName = agent.AgentName.Trim();
            agent.Address = agent.Address.Trim();
            agent.Phone = agent.Phone.Trim();
            _agentRepo.Update(agent);
        }

        public void DeleteAgent(int agentId)
        {
            if (agentId <= 0)
                throw new ArgumentException("Invalid agent ID.");

            try
            {
                _agentRepo.Delete(agentId);
            }
            catch (DbUpdateException)
            {
                throw new InvalidOperationException("Unable to delete the agent because it has associated order history.");
            }
        }

        private void ValidateAgent(Agent agent)
        {
            if (agent == null)
                throw new ArgumentNullException(nameof(agent));

            if (string.IsNullOrWhiteSpace(agent.AgentName))
                throw new ArgumentException("Agent name cannot be empty.");

            if (string.IsNullOrWhiteSpace(agent.Address))
                throw new ArgumentException("Agent address cannot be empty.");

            if (string.IsNullOrWhiteSpace(agent.Phone) || !Regex.IsMatch(agent.Phone.Trim(), @"^0\d{8,10}$"))
                throw new ArgumentException("Invalid phone number (must start with 0 and contain 9-11 digits).");
        }

        private bool IsUniqueConstraintViolation(DbUpdateException ex)
        {
            var sqlEx = ex.InnerException?.InnerException as SqlException;
            return sqlEx != null && (sqlEx.Number == 2627 || sqlEx.Number == 2601);
        }
    }
}
