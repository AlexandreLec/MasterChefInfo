using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimulationKitchen.Contract;
using System;
using TiledSharp;

namespace SimulationKitchen
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public const int WINDOW_WIDTH = 880; // dimmension fenètre jeu  
        public const int WINDOW_HEIGHT = 640; // dimmension fenètre jeu         
        TmxMap map; // déclaration de la méthode fourni par TiledSharp   
        public Texture2D tileset; // init des tiles en tant que Texture2D
        public int tileWidth; // Valeur Récupéré grace a TMXmap
        public int tileHeight; // Valeur Récupéré grace a TMXmap
        public int tilesetTilesWide;
        public int tilesetTilesHigh;
        public int[,] Tiles; // chaque tiles est séparer par une virgule (ref fichier de la map qui est en format CSV ex: 0,1,1,1 0= vide 1=Ground texture)
        int nbLayers = 8;
        // Affectation des textures2D 
        Texture2D textureKitchenChief;
        Texture2D textureCooker;
        Texture2D textureWasher;
        // Affection des Vector
        public static Vector2 positionKitchenChief { get; set; }

        public IModel Model { get; set; }


        public Game1(IModel model)
        {
            this.Model = model;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new TmxMap("Content/MapKitchenNew.tmx"); // On importe la map en tmx 
            tileset = Content.Load<Texture2D>(map.Tilesets[0].Name.ToString()); // On charge les textures du tileset = TilePerso                    
            //Début d'affectation des Tiles
            var version = map.Version;
            var myTileset = map.Tilesets["TileCuisine"];
            // Récupérations des tailles des Tiles
            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;
            // Récupérations des tailles HD des Tiles
            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;
            // Ajout des charactere en temps que texture 2D
            textureKitchenChief = Content.Load<Texture2D>("KitchenChief");
            textureCooker = Content.Load<Texture2D>("Cooker");
            textureWasher = Content.Load<Texture2D>("Washer");
            // Ajout d'une position aux sprites
            //positionKitchenChief = new Vector2(0, 0);
            positionKitchenChief = new Vector2(0, 0);

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            for (int numLayer = 0; numLayer < nbLayers; numLayer++)
            {
                for (var i = 0; i < map.Layers[numLayer].Tiles.Count; i++) //on compte le nombre de Tiles nécessaire pour faire la map.
                {
                    int gid = map.Layers[numLayer].Tiles[i].Gid; // On récupere l'id de la Tile.

                    if (gid == 0)
                    {
                        //Si l'id de la tile est 0 alors on affiche un "trou"
                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);
                        float x = (i % map.Width) * map.TileWidth; // On calcule les coordonnées de positionnement de la tile
                        float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight; // On calcule les coordonnées de positionnement de la tile
                        Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight); // On récupere la Tile d'origine
                        spriteBatch.Begin();
                        spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White); // On dessine la Tile
                        // on Draw les sprites des chara
                        spriteBatch.Draw(textureKitchenChief, positionKitchenChief, Color.White);

                        foreach (var cooker in this.Model.Cookers)
                        {
                            spriteBatch.Draw(textureCooker, cooker.Position, Color.White);
                        }
                        
                        //                       
                        spriteBatch.End();
                        base.Draw(gameTime);
                    }
                }
            }
        }
    }
}
