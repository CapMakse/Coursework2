
namespace Coursework.Targets
{
    /// <summary>
    /// Класс который хранит ссылку на объект Target
    /// </summary>
    class TargetContext
    {
        private Target Trg;
        /// <summary>
        /// Выбирает конкретную мишень (стратегию)
        /// </summary>
        /// <param name="Trg">Мишень которую нужно выбрать</param>
        public void SetTarget(Target Trg)
        {
            this.Trg = Trg;
        }
        /// <summary>
        /// Получает очки за выстрел
        /// </summary>
        /// <param name="X">Горизонтальная координата</param>
        /// <param name="Y">Вертикальная координата</param>
        /// <returns>Очки за выстрел</returns>
        public int GetScore(double X, double Y)
        {
            return Trg.GetScore(X, Y);
        }
        /// <summary>
        /// Проверяет отсутсвие мишени
        /// </summary>
        /// <returns>Отсутствует ли мишень</returns>
        public bool CheckLackTarget()
        {
            return Trg == null;
        }
        /// <summary>
        /// Возвращает название типа мишени
        /// </summary>
        /// <returns>Тип мишени</returns>
        public string GetTypeName()
        {
            return Trg.GetTypeName();
        }
    }
}
