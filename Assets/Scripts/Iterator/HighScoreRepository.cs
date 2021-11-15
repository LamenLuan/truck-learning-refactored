using System.Collections.Generic;

// Created by Luan Leme
public class HighScoreRepository : IHighScoreAggregate // Concrete Aggregate
{
    private List<HighScore> highScores;

    public HighScoreRepository()
    {
        highScores = new List<HighScore>();
    }

    public IIterator CreateIterator()
    {
        return new HighScoreIterator(highScores);
    }

    public void Add(HighScore highScore) {
        highScores.Add(highScore);
    }

    private class HighScoreIterator : IIterator // Concrete Iterator
    {
        private int index;
        private List<HighScore> highScores;

        public HighScoreIterator(List<HighScore> highScores)
        {
            this.highScores = highScores;
        }

        public HighScore Next()
        {
            return HasNext() ? highScores[index++] : null;
        }

        public bool HasNext()
        {
            return index < highScores.Count;
        }
    }
}