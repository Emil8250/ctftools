# ctftools
[![codecov](https://codecov.io/gh/Emil8250/ctftools/graph/badge.svg?token=MTV8B34LKJ)](https://codecov.io/gh/Emil8250/ctftools)

A collection of ctf tools written in C#.

If you want to contribute please read the [CONTRIBUTING](https://github.com/Emil8250/ctftools/blob/master/CONTRIBUTING.md).

## Usage
Simplest way to use this toolset, is to add the nuget package to your application:

```dotnet add package ctftools```

This will give you access to the ctftools object, which can be called: 

```ctftools.Encryption.ROT13.Rotate("Gu1fVmSynt{s14t}")```

```Th1sIzFlag{f14g}```

or ```ctftools.Format.Binary.ToText("011001100110110001100001011001110111101100110001001100100011001101111101")```

```flag{123}```
