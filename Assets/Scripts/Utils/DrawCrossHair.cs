using UnityEngine;

namespace Utils
{
    public class DrawCrossHair : MonoBehaviour
    {
        public static DrawCrossHair SharedInstance;
        public Texture2D crossNormal;
        public Texture2D crossAimed;
        private Transform _transform;
        private RaycastHit _raycastHit;
        private float _crossHairScale;
        private string _distance;
        private string _colliderName;
        private int _score;
        private bool _isEnemy;
        private void Start()
        {
            _transform = transform;
            SharedInstance = this;
            _score = 0;
        }

        private void OnGUI()
        {
            _raycastHit = GetIntersectionDistance();
            _crossHairScale = _raycastHit.collider == null ? 0.1f : (float)MyUtils.GetZoomScaleByDistance(_raycastHit.distance);
            _distance = _raycastHit.collider == null ? "Infinite" : _raycastHit.distance.ToString();
            _colliderName = _raycastHit.collider == null ? "None" : _raycastHit.collider.name;
            var styleHint = new GUIStyle {fontSize = 20};
            var styleScore = new GUIStyle {fontSize = 40};
            Texture2D crossTexture;
            styleScore.normal.textColor = Color.white;

            // Debug.Log("Scale: " + _crossHairScale);
            // crosshairImage.color = Color.Lerp(crosshairImage.color, m_CurrentCrosshair.crosshairColor, Time.deltaTime * crosshairUpdateshrpness);
            if (_colliderName.Contains("Enemy"))
            {
                styleHint.normal.textColor = Color.red;
                crossTexture = crossAimed;
            }else {
                styleHint.normal.textColor = Color.white;
                crossTexture = crossNormal;
            }
            // Draw crosshair (center of screen)
            GUI.DrawTexture(new Rect((Screen.width - crossTexture.width * _crossHairScale) / 2f, (Screen.height - crossTexture.height * _crossHairScale) / 2f, crossTexture.width * _crossHairScale, crossTexture.height * _crossHairScale), crossTexture);
            // Draw object name label (to right of crosshair)
            GUI.Label(new Rect((Screen.width + crossTexture.width * _crossHairScale + 10) / 2f, Screen.height * 0.5f - 40, 100, 80), "Enemy" + "\n" + _distance , styleHint);
            // Draw score label (top left of screen)
            GUI.Label(new Rect(Screen.width / 20f, Screen.height / 20f, Screen.width / 10f, Screen.width / 10f),"Your Score: " + _score, styleScore);
        }

        private void Update()
        {
            GetIntersectionDistance();
        }

        private RaycastHit  GetIntersectionDistance()
        {
            var position = _transform.position;
            var ray = new Ray(position, _transform.forward);
            Physics.Raycast(ray, out _raycastHit, Mathf.Infinity);
            return _raycastHit;
        }

        public void AddScore(int score)
        {
            _score += score;
        }
    }
}
