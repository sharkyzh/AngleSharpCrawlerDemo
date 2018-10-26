using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using TswwAngleSharpWeb.Models;

namespace TswwAngleSharpWeb.BLL
{
    public class LookUpDiffBLL
    {
        public static async Task<List<Agent>> GetDiffAgent()
        {
            List<Agent> diffAgentList = new List<Agent>();

            List<Agent> agentList;
            List<Tuan> tuanList;
            using (TswwDbContext context = new TswwDbContext())
            {
                agentList = await context.Agents.AsNoTracking().ToListAsync();
                tuanList = await context.Tuans.AsNoTracking().ToListAsync();
            }

            foreach (var agent in agentList)
            {
                if (!string.IsNullOrWhiteSpace(agent.BelongTuan))
                {
                    List<string> tuans = new List<string>();

                    var belongTuans = agent.TuanIds.Split('|');
                    if (belongTuans.Length > 1)
                    {
                        foreach (var belongTuan in belongTuans)
                        {
                            tuans.Add(belongTuan);
                        }
                    }
                    else
                    {
                        tuans.Add(agent.TuanIds);
                    }

                    foreach (var tuan in tuans)
                    {
                        if (!tuanList.Any(s => s.TuanId.Equals(tuan)))
                        {
                            diffAgentList.Add(agent);
                        }
                    }
                }
                else
                {
                    diffAgentList.Add(agent);
                }
            }
            return diffAgentList.OrderBy(s => s.BelongTuan).ToList();
        }
    }
}