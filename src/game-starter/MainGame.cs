using GameStarter.Debugging;
using GameStarter.Display;

namespace GameStarter;

class MainGame : Game
{
    public override void Initialize(string[] args)
    {
        Logging.StartLogging();
    }

    public override void LoadContent(string[] args)
    {

    }

    public override void Render()
    {
        DisplayManager.SwapBuffers();
    }

    public override void Unload()
    {

    }

    public override void Update()
    {

    }
}