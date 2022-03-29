using TextAdventure.Models;

namespace TextAdventure
{
    public sealed class GameManager
    {
        public GameManager()
        { 
            Dungeon = new Dungeon();
        }

        public Dungeon Dungeon { get; set; }
        public Room StartRoom { get; set; }
        
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public bool GameOver { get; set; }

        public void SetGameOver()
        {
            GameOver = true;
        }

    }
}