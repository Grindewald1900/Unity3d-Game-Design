using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utils;
using Random = UnityEngine.Random;

namespace EnemyScripts
{
    public class Enemy : MonoBehaviour
    {
        [FormerlySerializedAs("Slider")] public Slider slider;
        public GameObject player;
        public GameObject audioEffect;
        public Text textHealth;
        public Canvas canvas;
        public AudioSource destroyAudio;
        private Rigidbody _rigidbody;
        private float _healthPoint = 100f;
        private const float MoveSpeed = 2f;
        private bool _isAttacked;
        private Quaternion _initRotation;
    
        // Start is called before the first frame update
        private void Start()
        {
            player = GameObject.Find("Player");
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            audioEffect = GameObject.Find("AudioEffect");
            destroyAudio = audioEffect.GetComponent<AudioSource>();
            ResetEnemy();
            ResetCanvasRotation();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_isAttacked) return;
            MoveTowardsPlayer();
            transform.rotation = _initRotation;
        }
    
        public void GetAttacked(float damage)
        {
            _isAttacked = true;
            _healthPoint -= Random.Range(damage, damage * 0.5f);
            slider.value = _healthPoint;
            textHealth.text = (int)_healthPoint + " / " + slider.maxValue;

            if (_healthPoint <= slider.maxValue * 0.3f)
                slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
            if (_healthPoint <= 0)
            {
                destroyAudio.Play();
                if(gameObject.activeInHierarchy) 
                    DrawCrossHair.SharedInstance.AddScore(1);
                gameObject.SetActive(false);
                // Invoke("InactiveEnemy",1f);
            }
            _rigidbody.velocity = Vector3.zero;
        }

        private void MoveTowardsPlayer()
        {
            var playerPosition = player.transform.position;
            var position = transform.position;
            var distance = Vector3.Distance(position, playerPosition);
            var normalizedDirection = new Vector3((playerPosition.x - position.x) * Time.deltaTime * MoveSpeed/ distance,0f,(playerPosition.z - position.z)  * Time.deltaTime * MoveSpeed/ distance);
            canvas.transform.Rotate(Quaternion.FromToRotation(Vector3.forward, normalizedDirection).eulerAngles);
            transform.Translate(normalizedDirection);
            ResetCanvasRotation();
        }

        private void ResetCanvasRotation()
        {
            var direction = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);
            // transform.Rotate(Quaternion.FromToRotation(Vector3.forward, direction).eulerAngles);
            canvas.transform.Rotate(Quaternion.FromToRotation(Vector3.forward, direction).eulerAngles);
        }

        public void ResetEnemy()
        {
            var maxValue = slider.maxValue;
            _isAttacked = true;
            slider.value = maxValue;
            slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
            _healthPoint = maxValue;
            _initRotation = transform.rotation;
            textHealth.text = maxValue + "/" + maxValue;        
        }
    
        public void SetIsActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    
        public bool IsActiveInHierarchy()
        {
            return gameObject.activeInHierarchy;
        }

        public void SetLocation(Vector3 location)
        {
            transform.position = location;
        }
    
    
    }
}
