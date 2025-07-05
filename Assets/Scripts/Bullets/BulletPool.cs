using System.Collections.Generic;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }

        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}