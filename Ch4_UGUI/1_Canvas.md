#	UGUI

![](images/Example.gif)

일반적인 게임 객체와는 달리, Text, Button, Image와 같은 객체들은 조금 다른 방식으로 렌더링됩니다.

UGUI는 Unity GUI의 줄인말로, 유니티 엔진이 기본적으로 제공하는 UI 시스템을 말합니다.
기본적으로 많이 사용되는 UI 컴포넌트인 Text, Button, Slider 등 인터페이스가 제공됩니다.

또한, Callback 기능을 통해 UI 컴포넌트를 조작해서 자신이 작성한 Script의 함수를 실행할 수 있는 기능을 제공합니다.

이 챕터에서는 주로 많이 사용하는 UI 컴포넌트들을 간략하게 소개하고, 이들을 활용하는 방법을 알려드리고자 합니다.


##	Canvas

![](images/Canvas.png)

* Canvas는 유니티의 다양한 UI 객체들을 관리하는 직사각형 형태의 영역으로, 유니티 엔진에서 UI 기능을 활용하기 위한 가장 기본적인 UI 요소입니다.

* 모든 UI 요소들은 반드시 Canvas의 하위 객체로 설정되어야 올바르게 작동할 수 있습니다.


### Scene에 Canvas 추가하기

![](images/CanvasCreate.gif)

* Scene에 Canvas를 추가하기 위해서는 이전에 GameObject를 생성할 때 사용했던 **생성 메뉴**의 UI . 이미지와 같은 새 UI 요소를 만들면 자동으로 Canvas가 생성됩니다. UI 컴포넌트가 Canvas의 child로 설정해야 한다는 것을 잊지 마세요.


### RectTransform

![](images/RectTransform.png)

캔버스와 UI Component는 일반적인 GameObject의 Transform과는 달리 Scene에서 직사각형 형태의 영역으로 정의됩니다. 이러한 특수한 형태의 Transform을 RectTransform이라고 부르며, 아주 편리하게 UI 요소를 배치 할 수 있게 만들어주는 UI Component의 특징입니다.


### Canvas의 렌더링 순서

![](images/CanvasRenderingOrder.png)

* 캔버스의 UI 요소는 계층 구조에 나타나는 것과 동일한 순서로 그려집니다. 첫 번째 자식이 먼저 그려지고 두 번째 자식이 다음으로 그려집니다. 두 UI 요소가 겹치면 나중 요소가 이전 요소 위에 표시됩니다.

* 요소들이 언제나 첫 번째 자식 객체부터 그려지기 때문에, UI 요소들이 그려지는 순서를 변경하고 싶으면 Hierarchy 창에서 해당 요소의 배치 순서를 변경하면됩니다.


#### Rendering Mode

![](images/CanvasRenderingMode.png)

Rendering Mode는 Canvas가 그려지는 방식(렌더링 모드)을 설정합니다. 기본적으로 Canvas는 게임 화면 위에 Canavs의 UI 요소들이 그려지는 **Overlay** 렌더링 방식을 사용하지만, 경우에 따라서는 이 방식을 사용할 수 없는 경우도 있습니다. 예를 들어, **VR** 컨텐츠에서는 기술적인 특성상 Overlay 방식을 절대 사용할 수 없습니다. 따라서, 현재 컨텐츠 상황에 맞게 적절한 Rendering 모들를 설정하는 것이 중요합니다.

#### Screen Space - Overlay, Camera 모드

![](images/CanvasScreenSpace.png)

* **Screen Space - Overlay 모드**는 Scene 위에 렌더링 된 화면 위에 UI 요소를 그립니다. 화면 크기가 조정되거나 해상도가 변경되면 Canvas는 이에 맞게 자동으로 크기를 변경합니다.

* **Screen Space - Camera 모드**는 **Screen Space-Overlay 모드**와 유사하지만, 이 모드에서는 Canvas가 카메라 앞에 지정된 거리(Distance)만큼 떨어진 위치에서 Canvas 배치되어 렌더링됩니다. 따라서, Camera위치 변경에 따라 Canvas의 위치도 변경되며, 다른 Mesh에 가려지는 등 Canvas 밖에서 렌더링 되는 객체의 영향을 받을 수 있습니다.

#### World Space 모드

![](images/CanvasWorldSpace.png)

* World Space 모드는 다른 모드와는 다르게 작동하는데, 일반 GameObject처럼 캔버스와 UI 컴포넌트 들이가 3D 배치를 기반으로 장면의 다른 개체 앞이나 뒤에 렌더링됩니다.
* World Space 모드는 Screen Space를 사용하지 못하는 VR 컨텐츠에서 주로 사용되는 방식입니다.
