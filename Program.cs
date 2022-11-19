using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;


namespace Unit05.Game
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            Color head1 = new Color(0,0,0);
            head1 = Constants.GREEN;
            Color body1 = new Color(0,0,0);
            body1 = Constants.GREEN;
            Color head2 = new Color(0,0,0);
            head2 = Constants.RED;
            Color body2 = new Color(0,0,0);
            body2 = Constants.RED;  
                     
            // create the cast
            Cast cast = new Cast();

            cast.AddActor("snake", new Snake(head1, body1));
            cast.AddActor("snake", new Snake(head2, body2));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}