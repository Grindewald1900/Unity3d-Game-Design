using UnityEngine;

namespace Utils
{
    public class DrawCursor : MonoBehaviour
    {
        public Texture2D cursorTexture1;
        public Texture2D cursorTexture2;
        public Vector2 hotSpot = Vector2.zero;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.SetCursor(cursorTexture1, hotSpot, CursorMode.ForceSoftware);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.SetCursor(cursorTexture2, hotSpot, CursorMode.ForceSoftware);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Cursor.SetCursor(cursorTexture1, hotSpot, CursorMode.ForceSoftware);

            }
            {
                
            }
        }
        void OnMouseEnter()
        {
            Cursor.SetCursor(cursorTexture1, hotSpot, CursorMode.ForceSoftware);
        }

        // void OnMouseExit()
        // {
        //     Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        // }
    }
}
