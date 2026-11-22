using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AgentRepository
    {
        private readonly B2BWholesaleDBEntities _context;

        public AgentRepository()
        {
            _context = new B2BWholesaleDBEntities();
        }

        public List<Agent> GetAll()
        {
            return _context.Agents.ToList();
        }

        public Agent GetById(int id)
        {
            return _context.Agents.FirstOrDefault(a => a.AgentID == id);
        }

        public bool IsPhoneExists(string phone, int? excludeAgentId = null)
        {
            return _context.Agents.Any(
                a => a.Phone == phone
                && (!excludeAgentId.HasValue || a.AgentID != excludeAgentId.Value)
            );
        }

        public void Add(Agent agent)
        {
            _context.Agents.Add(agent);
            _context.SaveChanges();
        }

        public void Update(Agent agent)
        {
            var existing = _context.Agents.FirstOrDefault(
                a => a.AgentID == agent.AgentID
            );

            if (existing != null)
            {
                existing.AgentName = agent.AgentName;
                existing.Address = agent.Address;
                existing.Phone = agent.Phone;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var agent = _context.Agents.FirstOrDefault(a => a.AgentID == id);
            if (agent != null)
            {
                _context.Agents.Remove(agent);
                _context.SaveChanges();
            }
        }
    }
}
