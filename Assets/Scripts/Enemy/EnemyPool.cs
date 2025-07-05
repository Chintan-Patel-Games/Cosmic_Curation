using System.Collections.Generic;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyPrefab;
        private EnemyData enemyData;
        private List<PooledEnemy> pooledEnemies = new List<PooledEnemy>();

        public EnemyPool(EnemyView enemyPrefab, EnemyData enemyData)
        {
            this.enemyPrefab = enemyPrefab;
            this.enemyData = enemyData;
        }

        public EnemyController GetEnemy()
        {
            if (pooledEnemies.Count > 0)
            {
                PooledEnemy enemy = pooledEnemies.Find(item => !item.isUsed);
                if (enemy != null)
                {
                    enemy.isUsed = true;
                    return enemy.Enemy;
                }
            }
            return CreateNewPooledEnemy();
        }

        private EnemyController CreateNewPooledEnemy()
        {
            PooledEnemy newEnemy = new PooledEnemy();
            newEnemy.Enemy = CreateEnemy();
            newEnemy.isUsed = true;
            pooledEnemies.Add(newEnemy);
            return newEnemy.Enemy;
        }

        private EnemyController CreateEnemy() => new EnemyController(enemyPrefab, enemyData);

        public void ReturnEnemy(EnemyController enemy)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(e => e.Enemy.Equals(enemy));
            pooledEnemy.isUsed = false;
        }

        public class PooledEnemy
        {
            public EnemyController Enemy;
            public bool isUsed;
        }
    }
}