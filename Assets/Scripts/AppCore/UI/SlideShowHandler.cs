using System.Collections;
using UnityEngine;

namespace Common
{
    public class SlideShowHandler : MonoBehaviour
    {
        // Массив для хранения спрайтов
        public Sprite[] _slideShowSprites;
    
        // Интервал смены изображений
        public float changeInterval = 2.0f;

        // Компонент SpriteRenderer для смены изображений
        private SpriteRenderer spriteRenderer;
        private int currentIndex = 0;
        
        public void Setup(LotScreenData lotScreenData)
        {
            _slideShowSprites = lotScreenData.SlideShowSprites;
        }

        void Start()
        {
            // Получаем компонент SpriteRenderer
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Запускаем корутину для смены изображений
            StartCoroutine(ChangeImage());
        }

        IEnumerator ChangeImage()
        {
            while (true)
            {
                // Меняем спрайт на текущий
                spriteRenderer.sprite = _slideShowSprites[currentIndex];

                // Переход к следующему изображению
                currentIndex = (currentIndex + 1) % _slideShowSprites.Length;

                // Ждём указанный интервал
                yield return new WaitForSeconds(changeInterval);
            }
        }
    }
}