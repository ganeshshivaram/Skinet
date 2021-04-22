using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }
                                        = new List<Expression<Func<T, object>>>();

        protected void AddIncludes(Expression<Func<T, object>> inlcudeExpression)
        {
            Includes.Add(inlcudeExpression);
        }

    }
}