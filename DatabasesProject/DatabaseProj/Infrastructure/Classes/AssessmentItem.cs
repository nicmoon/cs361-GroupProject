using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Classes
{
    public class AssessmentItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Criteria> Criterion { get; set; }

        public List<CriteriaResult> CriteriaResults { get; set; }
    }
}
