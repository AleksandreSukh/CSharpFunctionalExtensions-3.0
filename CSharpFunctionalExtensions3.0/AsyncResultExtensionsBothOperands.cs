//namespace CSharpFunctionalExtensions3_0
//{
//    /// <summary>
//    /// Extentions for async operations where the task appears in the both operands
//    /// </summary>
//    public static class AsyncResultExtensionsBothOperands
//    {
//        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Trunc<T, Task<K>> func)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail<K>(result.Error);

//            K value = await func(result.Value);

//            return Result.Ok(value);
//        }

//        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Trunc<Task<T>> func)
//        {
//            Result result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail<T>(result.Error);

//            T value = await func().ConfigureAwait(false);

//            return Result.Ok(value);
//        }

//        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Trunc<T, Task<Result<K>>> func)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail<K>(result.Error);

//            return await func(result.Value);
//        }

//        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Trunc<Task<Result<T>>> func)
//        {
//            Result result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail<T>(result.Error);

//            return await func().ConfigureAwait(false);
//        }

//        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Trunc<Task<Result<K>>> func)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail<K>(result.Error);

//            return await func().ConfigureAwait(false);
//        }

//        public static async Task<Result> OnSuccess<T>(this Task<Result<T>> resultTask, Trunc<T, Task<Result>> func)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail(result.Error);

//            return await func(result.Value).ConfigureAwait(false);
//        }

//        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Trunc<Task<Result>> func)
//        {
//            Result result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return result;

//            return await func().ConfigureAwait(false);
//        }

//        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Trunc<T, Task<bool>> predicate, string errorMessage)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail<T>(result.Error);

//            if (!await predicate(result.Value).ConfigureAwait(false))
//                return Result.Fail<T>(errorMessage);

//            return Result.Ok(result.Value);
//        }

//        public static async Task<Result> Ensure(this Task<Result> resultTask, Trunc<Task<bool>> predicate, string errorMessage)
//        {
//            Result result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail(result.Error);

//            if (!await predicate().ConfigureAwait(false))
//                return Result.Fail(errorMessage);

//            return Result.Ok();
//        }

//        public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Trunc<T, Task<K>> func)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail<K>(result.Error);

//            K value = await func(result.Value).ConfigureAwait(false);

//            return Result.Ok(value);
//        }

//        public static async Task<Result<T>> Map<T>(this Task<Result> resultTask, Trunc<Task<T>> func)
//        {
//            Result result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//                return Result.Fail<T>(result.Error);

//            T value = await func().ConfigureAwait(false);

//            return Result.Ok(value);
//        }

//        public static async Task<Result<T>> OnSuccess<T>(this Task<Result<T>> resultTask, Trunc<T, Task> action)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsSuccess)
//            {
//                await action(result.Value).ConfigureAwait(false);
//            }

//            return result;
//        }

//        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Trunc<Task> action)
//        {
//            Result result = await resultTask.ConfigureAwait(false);

//            if (result.IsSuccess)
//            {
//                await action().ConfigureAwait(false);
//            }

//            return result;
//        }

//        public static async Task<T> OnBoth<T>(this Task<Result> resultTask, Trunc<Result, Task<T>> func)
//        {
//            Result result = await resultTask.ConfigureAwait(false);
//            return await func(result).ConfigureAwait(false);
//        }

//        public static async Task<K> OnBoth<T, K>(this Task<Result<T>> resultTask, Trunc<Result<T>, Task<K>> func)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);
//            return await func(result).ConfigureAwait(false);
//        }

//        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Trunc<Task> func)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//            {
//                await func().ConfigureAwait(false);
//            }

//            return result;
//        }

//        public static async Task<Result> OnFailure(this Task<Result> resultTask, Trunc<Task> func)
//        {
//            Result result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//            {
//                await func().ConfigureAwait(false);
//            }

//            return result;
//        }

//        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Trunc<string, Task> func)
//        {
//            Result<T> result = await resultTask.ConfigureAwait(false);

//            if (result.IsFailure)
//            {
//                await func(result.Error).ConfigureAwait(false);
//            }

//            return result;
//        }
//    }
//}
