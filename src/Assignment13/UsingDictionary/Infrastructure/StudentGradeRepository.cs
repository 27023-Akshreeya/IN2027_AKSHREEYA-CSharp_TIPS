namespace UsingDictionary.Infrastructure;

/// <summary>
/// Repository for managing student grades.
/// </summary>
/// <typeparam name="TKey">Type of the student identifier.</typeparam>
/// <typeparam name="TValue">Type of the grade value.</typeparam>
public class StudentGradeRepository<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _dictionary = new ();

    /// <summary>
    /// Adds a student and grade.
    /// </summary>
    /// <param name="key">Student identifier.</param>
    /// <param name="value">Student grade.</param>
    public void Add(TKey key, TValue value)
    {
        this._dictionary.Add(key, value);
    }

    /// <summary>
    /// Removes a student.
    /// </summary>
    /// <param name="key">Student identifier.</param>
    /// <returns>True if removed; otherwise, false.</returns>
    public bool Remove(TKey key)
    {
        return this._dictionary.Remove(key);
    }

    /// <summary>
    /// Checks whether a student exists.
    /// </summary>
    /// <param name="key">Student identifier.</param>
    /// <returns>True if the student exists; otherwise, false.</returns>
    public bool ContainsKey(TKey key)
    {
        return this._dictionary.ContainsKey(key);
    }

    /// <summary>
    /// Retrieves a student's grade.
    /// </summary>
    /// <param name="key">Student identifier.</param>
    /// <returns>The student's grade.</returns>
    public TValue Get(TKey key)
    {
        return this._dictionary[key];
    }

    /// <summary>
    /// Retrieves all students and grades.
    /// </summary>
    /// <returns>A collection of student-grade pairs.</returns>
    public IEnumerable<KeyValuePair<TKey, TValue>> GetAllStudents()
    {
        return this._dictionary;
    }
}
