namespace Mpdfin.Tests;

public class Parsing
{
    [Fact]
    public void Basic()
    {
        Request request = new("playlistinfo 0 10");
        Assert.Equal(Command.playlistinfo, request.Command);
        Assert.Equal(new List<string>() { "0", "10" }, request.Args);
    }

    [Fact]
    public void QuotedArgument()
    {
        Request request = new("pause \"1\"");
        Assert.Equal(Command.pause, request.Command);
        Assert.Equal(new List<string>() { "1" }, request.Args);
    }

    [Fact]
    public void QuotedWithSpace()
    {
        Request request = new("find \"multi word arg\"");
        Assert.Equal(Command.find, request.Command);
        Assert.Equal(new List<string>() { "multi word arg" }, request.Args);
    }

    [Fact]
    public void EscapedQuotesInArgument()
    {
        Request request = new("find \"multi \\\"word\\\" arg\"");
        Assert.Equal(Command.find, request.Command);
        Assert.Equal(new List<string>() { "multi \"word\" arg" }, request.Args);
    }
}