﻿using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions 
{
    public class MapAsyncRightTests : MapTestsBase 
    {
        [Fact]
        public async Task Map_AsyncRight_executes_on_success_returns_new_success()
        {
            Result result = Result.Success();
            Result<K> actual = await result.Map(Task_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            funcExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_AsyncRight_executes_on_failure_returns_new_failure()
        {
            Result result = Result.Failure(ErrorMessage);
            Result<K> actual = await result.Map(Task_Func_K);

            actual.IsSuccess.Should().BeFalse();
            funcExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_AsyncRight_T_executes_on_success_returns_new_success()
        {
            Result<T> result = Result.Success(T.Value);
            Result<K> actual = await result.Map(Task_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            funcExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_AsyncRight_T_executes_on_failure_returns_new_failure()
        {
            Result<T> result = Result.Failure<T>(ErrorMessage);
            Result<K> actual = await result.Map(Task_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(ErrorMessage);
            funcExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_AsyncRight_T_E_executes_on_success_returns_new_success()
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            Result<K, E> actual = await result.Map(Task_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            funcExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_AsyncRight_T_E_executes_on_failure_returns_new_failure()
        {
            Result<T, E> result = Result.Failure<T, E>(E.Value);
            Result<K, E> actual = await result.Map(Task_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            funcExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_AsyncRight_unit_result_E_executes_on_success_returns_success()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            Result<K, E> actual = await result.Map(Task_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            funcExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_AsyncRight_unit_result_E_executes_on_failure_returns_failure()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            Result<K, E> actual = await result.Map(Task_Func_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            funcExecuted.Should().BeFalse();
        }
    }
}
