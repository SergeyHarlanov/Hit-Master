    using System;
    using UnityEngine;

    public class Attack : StateMachine
    {
        public static Attack Instance;
        
        [SerializeField] private Transform _spaceSpawnBullet;
        
        private Animator _animator;
        private Player _player;
        private Camera _camera;

        private int _enemyCountOnPoint;
        public override void StartState()
        {
          //  Debug.Log("Attack true");

            _player.Attack = true;
        }

        public override void EndState()
        {
        //    Debug.Log("Attack false");

            _player.Attack = false;
        }

        public void UpdateCountEnemyOnpoint()
        {
            _enemyCountOnPoint--;
            if (_enemyCountOnPoint==0)
            {
               this.EndState();
            }
        }
        private void Start()
        {
            Instance = this;
            
            _player = GetComponent<Player>();
            _animator = GetComponent<Animator>();
            _camera = Camera.main;
        }

        private void Update()
        {
            Shooting();
        }
        private void Shooting()
        {
            if (Input.GetMouseButtonDown(0) && _player.Attack )
            {
                Ray ray =_camera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out RaycastHit hit);
                Vector3 dirBullet = hit.point - _spaceSpawnBullet.position;

                Transform bullet = ObjectPool.Instance.GetPoolObject().transform;
                bullet.position = _spaceSpawnBullet.position;
                
                Rigidbody bulletInst =  bullet.GetComponent<Rigidbody>();
                bulletInst.velocity =
                    dirBullet.normalized * GameProperty.Instance.BulletSpeed;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<TriggerPoint>(out  TriggerPoint triggerPoint))
            {
                _enemyCountOnPoint = triggerPoint.EnemyCount;
            }
        }
    }
