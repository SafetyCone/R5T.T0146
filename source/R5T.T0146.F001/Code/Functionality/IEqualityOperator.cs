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

            if (!lengthsAreEqualResult.Value)
            {
                return result;
            }

            // Test order (instance-by-instance) equality, for all instances.
            var instancesAreEqual = this.Array_Elements_ThroughAll_WithoutVerification(a, b,
                (a, b, index) =>
                {
                    var instanceEqualsResult = instanceEquals(a, b);

                    instanceEqualsResult.WithMetadata(
                        MetadataKeys.Instance.Index, index);

                    result.WithChild(instanceEqualsResult);

                    return instanceEqualsResult.Value;
                });

            if (!instancesAreEqual)
            {
                return result;
            }

            // Success.
            result.WithValue(true);

            return result;
        }

        /// <summary>
        /// Tests length and order equality.
        /// </summary>
        public void Array<T>(T[] a, T[] b,
            Func<T, T, Result<bool>> instanceEquals,
            Result<bool> resultToModify)
        {
            // Asumme failure.
            resultToModify
                .WithValue(false)
                ;

            // Test length.
            var lengthsAreEqualResult = this.Array_Length(a, b);

            resultToModify.WithChild(lengthsAreEqualResult);

            if (!lengthsAreEqualResult.Value)
            {
                return;
            }

            // Test order (instance-by-instance) equality, for all instances.
            var instancesAreEqual = this.Array_Elements_ThroughAll_WithoutVerification(a, b,
                (a, b, index) =>
                {
                    var instanceEqualsResult = instanceEquals(a, b);

                    instanceEqualsResult.WithMetadata(
                        MetadataKeys.Instance.Index, index);

                    resultToModify.WithChild(instanceEqualsResult);

                    return instanceEqualsResult.Value;
                });

            if (!instancesAreEqual)
            {
                return;
            }

            // Success.
            resultToModify.WithValue(true);
        }

        public new Result<bool> Array_Length(Array a, Array b)
        {
            var lengthsAreEqual = this.As<IEqualityOperator, F0000.IEqualityOperator>().Array_Length(a, b);

            var result = Instances.ResultOperator.Result(lengthsAreEqual)
                .WithTitle("Array length: check equality")
                .ModifyIf(!lengthsAreEqual,
                    x => x.WithFailure(Instances.MessageOperator.GetUnequalArrayLengths(a, b)));

            return result;
        }

        public new Result<bool> Dictionary_Count<TKey, TValue>(
			IDictionary<TKey, TValue> a,
			IDictionary<TKey, TValue> b)
        {
			var countsAreEqual = this.As<IEqualityOperator, F0000.IEqualityOperator>().Dictionary_Count(a, b);

			var result = Instances.ResultOperator.Result(countsAreEqual)
				.WithTitle("Dictionary count: check equality")
				.ModifyIf(!countsAreEqual,
					x => x.WithFailure(Instances.MessageOperator.GetUnequalDictionaryCounts(a, b)));

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
			var keysAreEqual = Instances.EqualityOperator.Collection_Values_ThroughAll_WithoutVerification(
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
						Instances.MetadataKeys.Key, key);

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

        //     public bool NullCheckDeterminesEquality_Else<T>(T a, T b,
        //Func<T, T, Result<bool>> equality,
        //out Result<bool> areEqualResult)
        //         where T : class
        //     {
        //         var nullCheckDeterminesEquality = Instances.NullOperator.NullCheckDeterminesEquality(a, b, out var areEqual);

        //areEqualResult = Instances.ResultOperator.New(areEqual)
        //	.WithTitle("Null check determines equality.")
        //	;

        //         if (nullCheckDeterminesEquality)
        //         {

        //         }

        //return nullCheckDeterminesEquality;
        //     }

        public bool NullCheckDeterminesEquality<T>(T a, T b,
            out Result<bool> areEqualResult)
            where T : class
        {
            var nullCheckDeterminesEquality = Instances.NullOperator.NullCheckDeterminesEquality(a, b, out var areEqual);

            areEqualResult = Instances.ResultOperator.New(areEqual)
                .WithTitle("Null check determines equality.")
                ;

            if (nullCheckDeterminesEquality)
            {
                var isNullA = Instances.NullOperator.Is_Null(a);
                var isNullB = Instances.NullOperator.Is_Null(b);

                if (!areEqual)
                {
                    var failureMessage = $"Null instance found:\nA is null: {isNullA}\nB is null: {isNullB}";

                    areEqualResult.WithFailure(failureMessage);
                }

                areEqualResult
                    .WithMetadata("IsNullA", isNullA)
                    .WithMetadata("IsNullB", isNullB)
                    ;
            }

            return nullCheckDeterminesEquality;
        }

		/// <summary>
		/// Returns a result ready to return from the caller.
		/// This is to say, returns a failure result if a type test determines equality (because that means the types are not equal).
		/// Otherwise a success result, because the types were equal (even though that means that a type test did not determine equality, which in a sense means that the method failed).
		/// </summary>
        /// <remarks>
        /// Will perform the null check internally.
        /// </remarks>
		public bool TypeCheckDeterminesEquality_WithNullCheck<T>(T a, T b, out Result<bool> typesAreEqualResult)
            where T: class
		{
            typesAreEqualResult = Instances.ResultOperator.New<bool>()
                .WithTitle("Type check determines equality.")
                ;

            // Test for null instances first.
            var nullCheckDeterminesEquality = this.NullCheckDeterminesEquality(a, b, out var areEqualResult);

            typesAreEqualResult.WithChild(areEqualResult);

            if (nullCheckDeterminesEquality)
            {
                var failureMessage = "One or both instances were null.";

                typesAreEqualResult.WithFailure(failureMessage);

                return nullCheckDeterminesEquality;
            }
            else
            {
                // Instances are not null.
                // Now test for type equality of instances.
                var typeDeterminesEquality = Instances.TypeOperator.TypeCheckDeterminesEquality(a, b, out var typesAreEqual);

                typesAreEqualResult.WithValue(typesAreEqual);

                if (typeDeterminesEquality)
                {
                    var namespacedTypeNameA = Instances.TypeOperator.Get_NamespacedTypeNameOf(a);
                    var namespacedTypeNameB = Instances.TypeOperator.Get_NamespacedTypeNameOf(b);

                    var failureMessage = $"Different types found:\n{namespacedTypeNameA}\n{namespacedTypeNameB}";

                    typesAreEqualResult
                        .WithFailure(failureMessage)
                        .WithMetadata("NamespacedTypeNameA", namespacedTypeNameA)
                        .WithMetadata("namespacedTypeNameB", namespacedTypeNameB)
                        ;
                }

                return typeDeterminesEquality;
            }
        }

        /// <summary>
        /// <inheritdoc cref="TypeCheckDeterminesEquality_WithNullCheck{T}(T, T, out Result{bool})" path="/summary"/>
        /// </summary>
        public bool TypeCheckDeterminesEquality_WithoutNullCheck<T>(T a, T b, out Result<bool> typesAreEqualResult)
        {
            typesAreEqualResult = Instances.ResultOperator.New<bool>()
                .WithTitle("Type check determines equality.")
                ;

            var typeDeterminesEquality = Instances.TypeOperator.TypeCheckDeterminesEquality(a, b, out var typesAreEqual);

            typesAreEqualResult.WithValue(typesAreEqual);

            if (typeDeterminesEquality)
            {
                var namespacedTypeNameA = Instances.TypeOperator.Get_NamespacedTypeNameOf(a);
                var namespacedTypeNameB = Instances.TypeOperator.Get_NamespacedTypeNameOf(b);

                var failureMessage = $"Different types found:\n{namespacedTypeNameA}\n{namespacedTypeNameB}";

                typesAreEqualResult
                    .WithFailure(failureMessage)
                    .WithMetadata("NamespacedTypeNameA", namespacedTypeNameA)
                    .WithMetadata("namespacedTypeNameB", namespacedTypeNameB)
                    ;
            }

            return typeDeterminesEquality;
        }
    }
}