using System;


namespace R5T.T0146.F001
{
	public class EqualityOperator : IEqualityOperator
	{
		#region Infrastructure

	    public static IEqualityOperator Instance { get; } = new EqualityOperator();

	    private EqualityOperator()
	    {
        }

	    #endregion
	}
}