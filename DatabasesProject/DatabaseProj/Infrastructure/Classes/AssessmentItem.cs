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

        public double AverageScore { get; set; }

        public int LowestScore { get; set; }

        public int HighestScore { get; set; }

        public List<Criteria> Criterion { get; set; }

        public List<CriteriaResult> CriteriaResults { get; set; }

		public string AddQuery {get
		{
			// todo return object for verification
			return "INSERT INTO AssessmentItem (`Name`) VALUES ('" + Name + "'); INSERT INTO AssessmentCriteria (`AssessmentId`, `CriteriaId`) VALUES " + Criterion.Select(x => "( LAST_INSERT_ID(), " + x.Id + " )").Aggregate((x, y) => x + ", " + y) + "; SELECT 1 AS `Id`;";
		}}
    }
}
