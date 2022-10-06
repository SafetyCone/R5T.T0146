using System;


namespace R5T.T0146
{
	public class ReasonOperator : IReasonOperator
	{
		#region Infrastructure

	    public static ReasonOperator Instance { get; } = new();

	    private ReasonOperator()
	    {
        }

	    #endregion
	}
}