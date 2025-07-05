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

        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullet item = pooledBullets.Find(item => !item.isUsed);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.Bullet;
                }
            }
            return CreateNewPooledBullet();
        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullet newBullet = new PooledBullet();
            newBullet.Bullet = new BulletController(bulletPrefab, bulletSO);
            newBullet.isUsed = true;
            pooledBullets.Add(newBullet);
            return newBullet.Bullet;
        }

        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }
    }
}