using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? GenerateRandomImplement<T>()
    {
        var random = new Random();

        return typeof(T) switch
        {
            Type byteType when byteType == typeof(byte) => random.NextByteImplement().ParseImplement<T>(),
            Type sbyteType when sbyteType == typeof(sbyte) => random.NextSbyteImplement().ParseImplement<T>(),
            Type shortType when shortType == typeof(short) => random.NextShortImplement().ParseImplement<T>(),
            Type ushortType when ushortType == typeof(ushort) => random.NextUshortImplement().ParseImplement<T>(),
            Type intType when intType == typeof(int) => random.NextIntImplement().ParseImplement<T>(),
            Type uintType when uintType == typeof(uint) => random.NextUintImplement().ParseImplement<T>(),
            Type longType when longType == typeof(long) => random.NextLongImplement().ParseImplement<T>(),
            Type ulongType when ulongType == typeof(ulong) => random.NextUlongImplement().ParseImplement<T>(),
            Type nintType when nintType == typeof(nint) => random.NextNintImplement().ParseImplement<T>(),
            Type nuintType when nuintType == typeof(nuint) => random.NextNuintImplement().ParseImplement<T>(),
            Type floatType when floatType == typeof(float) => random.NextSingleImplement().ParseImplement<T>(),
            Type doubleType when doubleType == typeof(double) => random.NextDoubleImplement().ParseImplement<T>(),
            Type decimalType when decimalType == typeof(decimal) => random.NextDecimalImplement().ParseImplement<T>(),
            Type dateTimeType when dateTimeType == typeof(DateTime) => random.NextDateTimeImplement().ParseImplement<T>(),
            Type charType when charType == typeof(char) => random.NextCharImplement().ParseImplement<T>(),
            Type stringType when stringType == typeof(string) => random.NextStringImplement().ParseImplement<T>(),
            _ => random.NextBoolImplement().ParseImplement<T>(),
        };
    }
}
