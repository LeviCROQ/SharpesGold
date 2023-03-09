namespace SharpesGold.Maps.Tests;

public class MapTests
{
    [SetUp]
    public void Setup()
    {
        // In case any setup required
    }

    [Test]
    public void SanityTest()
    {
        SharpesMaps maps = new SharpesMaps();
        Assert.That(maps.GetCount(), Is.EqualTo(3));
        Assert.That(maps.GetName(1), Is.EqualTo("Second hello world a bit longer"));
        Assert.That(maps.GetObstacle(0, 0, 0), Is.EqualTo(0));
        Assert.That(maps.GetObstacle(0, 0, 1), Is.EqualTo(1));
        Assert.That(maps.GetObstacle(0, 0, 1), Is.EqualTo(1));
        Assert.That(maps.GetObstacle(0, 0, 1), Is.EqualTo(1));
        Assert.That(maps.GetObstacle(0, 0, 4), Is.EqualTo(0));
        Assert.That(maps.GetObstacle(2, 0, 5), Is.EqualTo(0));
        Assert.That(maps.GetObstacle(2, 1, 5), Is.EqualTo(1));
        Assert.That(maps.GetObstacle(2, 2, 5), Is.EqualTo(1));
        Assert.That(maps.GetObstacle(2, 3, 5), Is.EqualTo(0));
        Assert.That(maps.GetObstacle(2, 4, 5), Is.EqualTo(1));
        Assert.That(maps.GetObstacle(2, 5, 5), Is.EqualTo(1));
        Assert.That(maps.GetObstacle(2, 6, 5), Is.EqualTo(0));
    }

    [Test]
    public void NamesTest()
    {
        SharpesMaps maps = new SharpesMaps();

        Assert.That(maps.GetName(0), Is.EqualTo("First"));
        Assert.That(maps.GetName(1), Is.EqualTo("Second hello world a bit longer"));
        Assert.That(maps.GetName(2), Is.EqualTo("Third"));
    }

    [Test]
    public void SwapMapFileTest()
    {
        SharpesMaps maps = new SharpesMaps(@"src\SharpesGold.Maps\SharpesTestMaps.json");
        Assert.That(maps.GetName(0), Is.EqualTo("Uno"));
        Assert.That(maps.GetName(1), Is.EqualTo("Dos"));
        Assert.That(maps.GetCount(), Is.EqualTo(2));
    }

    [Test]
    public void ObstacleTest() 
    {

        SharpesMaps maps = new SharpesMaps();
        Assert.That(maps.GetObstacle(0, 1, 1), Is.EqualTo(1));

        Assert.That(maps.GetObstacle(0, 0, 0), Is.EqualTo(0));

    }
}