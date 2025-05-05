using System.Diagnostics;
using static System.Nullable;

namespace YANLib.Implementation;

internal static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? GenerateRandomImplement<T>()
    {
        var targetType = typeof(T);

        if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            targetType = GetUnderlyingType(typeof(T))!;
        }

        var random = new Random();
        object? raw = targetType switch
        {
            Type byteType when byteType == typeof(byte) => random.NextByteImplement(),
            Type sbyteType when sbyteType == typeof(sbyte) => random.NextSbyteImplement(),
            Type shortType when shortType == typeof(short) => random.NextShortImplement(),
            Type ushortType when ushortType == typeof(ushort) => random.NextUshortImplement(),
            Type intType when intType == typeof(int) => random.NextIntImplement(),
            Type uintType when uintType == typeof(uint) => random.NextUintImplement(),
            Type longType when longType == typeof(long) => random.NextLongImplement(),
            Type ulongType when ulongType == typeof(ulong) => random.NextUlongImplement(),
            Type nintType when nintType == typeof(nint) => random.NextNintImplement(),
            Type nuintType when nuintType == typeof(nuint) => random.NextNuintImplement(),
            Type floatType when floatType == typeof(float) => random.NextSingleImplement(),
            Type doubleType when doubleType == typeof(double) => random.NextDoubleImplement(),
            Type decimalType when decimalType == typeof(decimal) => random.NextDecimalImplement(),
            Type dateTimeType when dateTimeType == typeof(DateTime) => random.NextDateTimeImplement(),
            Type charType when charType == typeof(char) => random.NextCharImplement(),
            Type stringType when stringType == typeof(string) => random.NextStringImplement(),
            _ => random.NextBoolImplement()
        };

        return raw.ParseImplement<T>();
    }
}
