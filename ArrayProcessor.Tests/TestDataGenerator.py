import sys
import json

def generate_test_data():
    test_cases = []
    
    # Границы для double в C#
    min_double = -1.7976931348623157E+308
    max_double = 1.7976931348623157E+308
    
    # 1. Минимальная граница
    test_cases.append({
        "name": "MinBoundary",
        "input": [min_double],
        "sum": 0.0,
        "product": min_double
    })
    
    # 2. Максимальная граница
    test_cases.append({
        "name": "MaxBoundary",
        "input": [max_double],
        "sum": max_double,
        "product": max_double
    })
    
    # 3. Ноль
    test_cases.append({
        "name": "Zero",
        "input": [0.0],
        "sum": 0.0,
        "product": 0.0
    })
    
    # 4. Между минимумом и нулем
    test_cases.append({
        "name": "BetweenMinAndZero",
        "input": [-100.5, -50.3, -10.1],
        "sum": 0.0,
        "product": -100.5
    })
    
    # 5. Между нулем и максимумом
    test_cases.append({
        "name": "BetweenZeroAndMax",
        "input": [10.5, 50.3, 100.1],
        "sum": 161.9,
        "product": 10.5 * 100.1
    })
    
    # 6. Смешанные значения
    test_cases.append({
        "name": "MixedValues",
        "input": [1.0, -2.0, 3.0, -4.0, 5.0],
        "sum": 9.0,
        "product": 1.0 * 3.0 * 5.0
    })
    
    # 7. Все положительные
    test_cases.append({
        "name": "AllPositive",
        "input": [1.5, 2.5, 3.5, 4.5],
        "sum": 12.0,
        "product": 1.5 * 3.5
    })
    
    # 8. Все отрицательные
    test_cases.append({
        "name": "AllNegative",
        "input": [-1.5, -2.5, -3.5, -4.5],
        "sum": 0.0,
        "product": -1.5 * -3.5
    })
    
    # 9. Положительный элемент первый
    test_cases.append({
        "name": "PositiveFirst",
        "input": [5.0, -2.0, -3.0],
        "sum": 5.0,
        "product": 5.0 * -3.0
    })
    
    # 10. Положительный элемент в середине
    test_cases.append({
        "name": "PositiveMiddle",
        "input": [-1.0, 5.0, -3.0],
        "sum": 5.0,
        "product": -1.0 * -3.0
    })
    
    # 11. Положительный элемент последний
    test_cases.append({
        "name": "PositiveLast",
        "input": [-1.0, -2.0, 5.0],
        "sum": 5.0,
        "product": -1.0 * 5.0
    })
    
    # 12. Один элемент положительный
    test_cases.append({
        "name": "SinglePositive",
        "input": [42.5],
        "sum": 42.5,
        "product": 42.5
    })
    
    # 13. Один элемент отрицательный
    test_cases.append({
        "name": "SingleNegative",
        "input": [-42.5],
        "sum": 0.0,
        "product": -42.5
    })
    
    # 14. Большой массив положительных
    test_cases.append({
        "name": "LargeArrayPositive",
        "input": [i * 1.0 for i in range(1, 101)],
        "sum": sum(range(1, 101)),
        "product": 1.0 * 3.0 * 5.0 * 7.0 * 9.0  # первые 5 четных индексов для примера
    })
    
    with open('test_data.json', 'w') as f:
        json.dump(test_cases, f, indent=2)
    
    print("Test data generated successfully!")

if __name__ == "__main__":
    generate_test_data()