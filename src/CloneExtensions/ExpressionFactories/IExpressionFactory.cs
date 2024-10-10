using System.Linq.Expressions;
namespace UnlockedData.CloneExtensions.ExpressionFactories
{
    interface IExpressionFactory<T>
    {
        bool IsDeepCloneDifferentThanShallow { get; }

        bool AddNullCheck { get; }

        bool VerifyIfAlreadyClonedByReference { get; }

        Expression GetShallowCloneExpression();

        Expression GetDeepCloneExpression();
    }
}
