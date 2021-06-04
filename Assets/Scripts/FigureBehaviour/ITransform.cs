using System.Collections;

/// <summary>
/// Абстракция какой либо траснформации фигуры
/// </summary>
public interface ITransform {

    void SetStartTransform(float[] start);
    
    /// <summary>
    /// Перемещение, вращение, смена цвета
    /// </summary>
    /// <returns>Для вызова курутины в монобехе</returns>
    IEnumerator Translate();

    /// <summary>
    /// Для надежной сериализации в json
    /// </summary>
    /// <returns></returns>
    BehaviorStruct ToStruct();
}
