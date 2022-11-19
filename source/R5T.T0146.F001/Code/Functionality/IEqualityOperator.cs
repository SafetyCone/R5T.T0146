using System;
using System.Collections.Generic;
using System.Extensions;

using R5T.T0132;


namespace R5T.T0146.F001
{
	[FunctionalityMarker]
	public partial interface IEqualityOperator : IFunctionalityMarker,
		F0000.IEqualityOperator
	{
		public new Result<bool> Dictionary_Count<TKey, TValue>(
			IDictionary<TKey, TValue> a,
			IDictionary<TKey, TValue> b)
        {
			var countsAreEqual = this.As<IEqualityOperator, F0000.IEqualityOperator>().Dictionary_Count(a, b);

			var result = ResultOperator.Instance.Result(countsAreEqual)
				.WithTitle("Dictionary count: check equality")
				.ModifyIf(!countsAreEqual,
					x => x.WithFailure(F0000.MessageOperator.Instance.GetUnequalDictionaryCounts(a, b)));

			return result;
		}

		/// <summary>
		/// Tests count, key order, and value equality.
		/// </summary>
		public Result<bool> Dictionary<TKey, TValue>(
			IDictionary<TKey, TValue> a,
			IDictionary<TKey, TValue> b,
			Func<TKey, TKey, Result<bool>> keyEquals,
			Func<TValue, TValue, Result<bool>> valueEquals)
        {
			var result = ResultOperator.Instance.New<bool>()
				// Assume failure.
				.WithValue(false);

			// Test count.
			var countsAreEqualResult = this.Dictionary_Count(a, b);

			result.WithChild(countsAreEqualResult);

			if (!countsAreEqualResult.Value)
			{
				return result;
			}

			// Test key order (instance-by-instance) equality, for all instances.
			var keysAreEqual = F0000.EqualityOperator.Instance.Collection_Values_ThroughAll_WithoutVerification(
				a.Keys,
				b.Keys,
				(a, b) =>
				{
					var instanceEqualsResult = keyEquals(a, b);

					result.WithChild(instanceEqualsResult);

					return instanceEqualsResult.Value;
				});

			if (!keysAreEqual)
			{
				return result;
			}

			// Test values.
			var allValuesAreEqual = true;

            foreach (var key in a.Keys)
            {
				var valueA = a[key];
				var valueB = b[key];

				var valuesAreEqualResult = valueEquals(valueA, valueB)
					.WithMetadata(
						MetadataKeys.Instance.Key, key);

				result.WithChild(valuesAreEqualResult);

				allValuesAreEqual &= valuesAreEqualResult.Value;
			}

			if (!allValuesAreEqual)
			{
				return result;
			}

			// Success.
			result.WithValue(true);

			return result;
		}

		public new Result<bool> Array_Length(Array a, Array b)
        {
			var lengthsAreEqual = this.As<IEqualityOperator, F0000.IEqualityOperator>().Array_Length(a, b);

			var result = ResultOperator.Instance.Result(lengthsAreEqual)
				.WithTitle("Array length: check equality")
				.ModifyIf(!lengthsAreEqual,
					x => x.WithFailure(F0000.MessageOperator.Instance.GetUnequalArrayLengths(a, b)));

			return result;
		}

		/// <summary>
		/// Tests length and order equality.
		/// </summary>
		public Result<bool> Array<T>(T[] a, T[] b,
			Func<T, T, Result<bool>> instanceEquals)
        {
			var result = ResultOperator.Instance.New<bool>()
				// Assume failure.
				.WithValue(false);

			// Test length.
			var lengthsAreEqualResult = this.Array_Length(a, b);

			result.WithChild(lengthsAreEqualResult);

			if(!lengthsAreEqualResult.Value)
            {
				return result;
            }

			// Test order (instance-by-instance) equality, for all instances.
			var instancesAreEqual = F0000.EqualityOperator.Instance.Array_Elements_ThroughAll_WithoutVerification(a, b,
				(a, b, index) =>
				{
					var instanceEqualsResult = instanceEquals(a, b);

					instanceEqualsResult.WithMetadata(
						MetadataKeys.Instance.Index, index);

					result.WithChild(instanceEqualsResult);

					return instanceEqualsResult.Value;
				});

			if(!instancesAreEqual)
            {
				return result;
            }

			// Success.
			result.WithValue(true);

			return result;
        }
	}
}