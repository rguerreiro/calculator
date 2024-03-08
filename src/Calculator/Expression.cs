using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Expression
    {
        private readonly List<ITerm> _terms = [];

        public void AddTerm(ITerm term)
        {
            term.Id = _terms.Count + 1;
            _terms.Add(term);
        }

        public decimal Calc()
        {
            var operations = _terms.Where(x => x is Operation).OrderByDescending(x => x.Priority).Cast<Operation>().ToList();

            foreach (var op in operations)
            {
                var left = _terms.First(x => x.Id == op.Id - 1);
                var right = _terms.First(x => x.Id == op.Id + 1);

                while (left.Captured) left = left.BelongsTo;
                while (right.Captured) right = right.BelongsTo;

                op.Set(left, right);
            }

            return operations.Last().Calc();
        }
    }
}
