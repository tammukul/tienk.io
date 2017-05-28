//
//  Copyright (c) 2017  FederationOfCoders.org
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using UnityEngine;
using Tienkio.Pools;

namespace Tienkio.Tanks {
    public class Bullet : MonoBehaviour {
        [HideInInspector]
        public TankController tank;

        [HideInInspector]
        public float health, damage, knockback, flyTime;
        public float slowDownSpeed;

        [HideInInspector]
        public Vector3 normalVelocity;

        new Rigidbody rigidbody;

        PoolObject poolObject;

        float startTime;

        void Awake() {
            rigidbody = GetComponent<Rigidbody>();
            poolObject = GetComponent<PoolObject>();
        }

        public void Start() {
            startTime = Time.time;
        }

        void FixedUpdate() {
            float timeFromStart = Time.time - startTime;
            if (timeFromStart >= flyTime || health <= 0)
                poolObject.PutIntoPool();
            else
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, normalVelocity, Time.deltaTime * slowDownSpeed);
        }
    }
}
