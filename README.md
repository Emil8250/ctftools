# ctftools
[![codecov](https://codecov.io/gh/Emil8250/ctftools/graph/badge.svg?token=MTV8B34LKJ)](https://codecov.io/gh/Emil8250/ctftools)

A collection of CTF tools written in C#.

If you want to contribute, please read the [CONTRIBUTING](https://github.com/Emil8250/ctftools/blob/master/CONTRIBUTING.md).

## Usage
The simplest way to use this toolset is to add the NuGet package to your application:

```dotnet add package ctftools```

This will give you access to the `ctftools` object, which can be called for various tasks:

### Encryption

#### ROT13 Encryption

```csharp
ctftools.Encryption.ROT13.Rotate("Gu1fVmSynt{s14t}");
// Output: "Th1sIzFlag{f14g}"
```

### Format

#### Base64

```csharp
ctftools.Format.Base64.ToText("ZmxhZ3tiYXNlNjR9");
// Output: "flag{base64}"
ctftools.Format.Base64.ToBase64("flag{base64}");
// Output: "ZmxhZ3tiYXNlNjR9"
```

#### Binary

```csharp
ctftools.Format.Binary.ToText("01100110 01101100 01100001 01100111 01111011 00110001 00110010 00110011 01111101");
// Output: "flag{123}"
```

#### Hex

```csharp
ctftools.Format.Hex.ToInt("ff");
// Output: 255
ctftools.Format.Hex.ToText(255);
// Output: "FF"
```

### Socket

#### Remote

```csharp
var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
r.SendLine("This is test\nAssertThis");
var result = r.ReadLineUntil("Assert");
Assert.Equal("AssertThis", result);

var r = new ctftools.Socket.Remote("tcpbin.com", 4242);
r.SendLine("This is a test");
var expectedBytes = Encoding.ASCII.GetBytes("This is a test");
byte[] result = r.ReadBytes(expectedBytes.Length);
Assert.Equal(expectedBytes, result);
```
This updated README now includes more examples for different methods, grouped by namespaces for clarity and convenience.



