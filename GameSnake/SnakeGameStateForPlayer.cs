﻿using Common;
using GameCore;
using System.Collections.Generic;
using System.Linq;

namespace GameSnake
{
    public class SnakeGameStateForPlayer : ISnakeGameStateForPlayer
    {
        private GameState gameState;
        private Snake snakePlayer;

        public SnakeGameStateForPlayer(GameState gameState, Snake snakePlayer)
        {
            this.gameState = gameState;
            this.snakePlayer = snakePlayer;
        }

        public int MapWidth => gameState.MapWidth;

        public int MapHeight => gameState.MapHeight;

        public ICreature GetCreatureOrNull(Point point) => gameState.GetCreatureOrNull(point);

        public bool IsApple(Point point)
        {
            return gameState.GetCreatureOrNull(point) is Apple;
        }

        public Point MySnakeHead => snakePlayer.Head.Point;
        public List<Point> MySnakeBody => snakePlayer.Tail.Select(v => v.Point).ToList();
    }
}