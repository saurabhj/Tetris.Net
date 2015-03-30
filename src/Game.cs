using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tetris {
    public class Game {

        #region Private Properties

        // Registering all shapes here
        private static List<Type> _gameShapes = new List<Type>();

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game() {
            // Uses reflection to get a list of all Classes inherited from the Shape Class
            _gameShapes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(Shape).IsAssignableFrom(t) && t != typeof(Shape)).ToList();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// State of the Game. 
        /// True = Game is Active
        /// False = Game Over
        /// </summary>
        /// <value>
        ///   <c>true</c> if state; otherwise, <c>false</c>.
        /// </value>
        public bool State { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a random new shape from the list.
        /// </summary>
        /// <param name="rnd">The random.</param>
        /// <returns></returns>
        public Shape GetNewShape(Random rnd) {
            var type = _gameShapes[rnd.Next(_gameShapes.Count)];
            return (Shape)Activator.CreateInstance(type);
        }

        #endregion

    }
}
