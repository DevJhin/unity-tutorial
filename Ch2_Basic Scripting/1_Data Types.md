# 유니티 프로그래밍
이번 챕터에서는 유니티 C# 프로그래밍에서 사용되는 프로그래밍에 대해 본격적으로 설명드리고자 합니다. 유니티에서 사용되는 C# 언어는 C/C++ 언어, 특히 Java 언어의 문법과 상당히 유사하기 때문에, 이전에 프로그래밍 경험이 있으시다면 빠르게 적응하실 수 있을 것입니다.


**왜 유니티 엔진은 C# 언어를 사용하나요?**
사실, 유니티 엔진의 핵심 코드는 전부 C++언어로 작성되어 있습니다. 하지만, 정작 우리가 유니티 엔진에서 프로그래밍을 할 때에는 C# 언어를 사용합니다. C#언어를 활


1. C/C++과 같은 low-level 언어보다 배우고 활용하기 쉽습니다.
메모리 관리,
특히, C# 같은 경우,  메모리 관리와 같이 까다롭고 복잡한 작업을 기본적으로 언어 차원에서 지원합니다. 따라서, C/C++

2. 일반적으로, C#은 Java 나 Python 같은 언어 보다 뛰어난 성능을 보입니다.
따라서, C/C++보다는 성능이 떨어지지만, Java나 Python 같은 주요 언어들보다는 성능이 높기 때문에

이와 같은 특징 때문에 유니티 엔진이 타 게임 엔진보다 진입 장벽이 낮고 활용이 편리하다는 장점을 가지게 되었습니다.



## 기본 자료형
우선, 유니티 프로그래밍에서 가장 많이 쓰이는 데이터 타입을 몇 가지 알아봅시다.


### int
4바이트 정수형 데이터 타입입니다. 개수, 카운트 변수 등 정수 개념을 다룰 때에는 `int`를 사용합니다.
```cs
int num = 3;
```

### float
4바이트 실수형 데이터 타입입니다. 시간, 비율, 좌표 등 실수 개념을 다룰 때에는 `float`를 사용합니다.

```cs
float time = 3.0f;
```
`double`과 구분하기 위해, float 리터럴을 입력할 때는 숫자 뒤에 `f`를 붙여야 합니다.

**알아두세요**
>일반적으로 많이 쓰이는 실수 자료형 중에서는 `double`도 있지만, 유니티 엔진에서는 정밀도는 낮지만 메모리 크기와 연산 성능이 뛰어난 `float` 자료형을 주로 사용합니다.


### bool
참/거짓을 표현하는 boolean 기본 데이터 타입입니다.

```cs
bool isMine = false;
```

## 구조체

구조체는

### Vector3
- x, y, z 3개의 float 값으로 구성된 3차원 벡터입니다.
- 3차원 정보인 Position(위치), Euler Angle(회전)등을 표현할 수 있으며, 유니티에서 정말 많이 사용되는 데이터 타입입니다.
```cs
Vector3 position = transform.position;
```

또한 Vector3 타입은 여러가지 수학 연산들을 지원하는 메소드를 가지고 있으니, 복잡한 3차원 벡터 수학 연산들을 직접 구현하실 필요는 없습니다.

```cs

Vector3 a = new Vector3(1,2,3);
Vector3 b = new Vector3(4,5,6);

//Dot product 연산
float magnitude = a.magnitude;
//
float distance = Vector3.Distance(a, b);

float dot = Vector3.Dot(a, b);
```


유니티 엔진은 3차원 벡터 뿐만 아니라 Vector2, Vector4와 같은 2차원, 4차원 벡터도 지원합니다. 활용법은 Vector3와 거의 동일합니다.


### Quaternion
- Rotation을
- Gymbal Lock 현상을 방지할 수 있음.




## string
문자열을 표현하는 데이터 타입입니다. `string`은 문자열을 표현할 문자열과 관련된 여러가지 기능들이 지원됩니다.

```cs
string name;
```


특히, 문자열끼리 서로 더하기 연산을 수행하여 문자열을 합칠수도 있습니다.
```cs
string firstName = "John";
string lastName = "Doe";

string name = "John" + " "+ "Doe";

Debug.Log(name);
//결과: name => "John Doe"
```



## Reference
[Introduction to Unity: Getting Started 1/2]
https://www.raywenderlich.com/7514-introduction-to-unity-getting-started-part-1-2#toc-anchor-003
