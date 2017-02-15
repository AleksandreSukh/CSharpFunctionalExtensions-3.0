using System;
using ALCS.Net3MigrationHelper.Delegates;

namespace CSharpFunctionalExtensions
{
    public static class ResultExtensions
    {
        public static Result<K> OnSuccess<T, K>(this Result<T> result, Trunc<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(func(result.Value));
        }

        public static Result<T> OnSuccess<T>(this Result result, Trunc<T> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return Result.Ok(func());
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Trunc<T, Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return func(result.Value);
        }

        public static Result<T> OnSuccess<T>(this Result result, Trunc<Result<T>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return func();
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Trunc<Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return func();
        }

        public static Result OnSuccess<T>(this Result<T> result, Trunc<T, Result> func)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return func(result.Value);
        }

        public static Result OnSuccess(this Result result, Trunc<Result> func)
        {
            if (result.IsFailure)
                return result;

            return func();
        }

        public static Result<T> Ensure<T>(this Result<T> result, Trunc<T, bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            if (!predicate(result.Value))
                return Result.Fail<T>(errorMessage);

            return Result.Ok(result.Value);
        }

        public static Result Ensure(this Result result, Trunc<bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            if (!predicate())
                return Result.Fail(errorMessage);

            return Result.Ok();
        }

        public static Result<K> Map<T, K>(this Result<T> result, Trunc<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(func(result.Value));
        }

        public static Result<T> Map<T>(this Result result, Trunc<T> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return Result.Ok(func());
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }

        public static Result OnSuccess(this Result result, Fiction action)
        {
            if (result.IsSuccess)
            {
                action();
            }

            return result;
        }

        public static T OnBoth<T>(this Result result, Trunc<Result, T> func)
        {
            return func(result);
        }

        public static K OnBoth<T, K>(this Result<T> result, Trunc<Result<T>, K> func)
        {
            return func(result);
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Fiction action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result OnFailure(this Result result, Fiction action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }
    }
}
