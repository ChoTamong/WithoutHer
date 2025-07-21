## Without Her
<img width="1197" height="437" alt="image" src="https://github.com/user-attachments/assets/da4984e3-2efd-47b3-9c19-7ea25e314892" />
&nbsp;
  
## 목차
1. [ 프로젝트 개요 ](#-easymemd가-뭐예요)
2. [ 게임 시연](#-좀-더-구체적으로-가르쳐주세요)
3. [ 구현 기능](#-좀-더-구체적으로-가르쳐주세요)
4. [ 핵심 기능](#-좀-더-구체적으로-가르쳐주세요)
5. [ 트러블 슈팅](#-좀-더-구체적으로-가르쳐주세요)
6. [ 프로젝트 회고](#-좀-더-구체적으로-가르쳐주세요)
&nbsp;

## 프로젝트 개요
한 남자의 절박한 선택과 그로 인한 비극적 여정을 다룬 게임 
- 게임 이름: Without Her
- 장르: 텍스트 기반 RPG
- 컨셉: 선과 악의 경계에서 고뇌하는 한 남자의 감옥 탈출기
- 특징: 선택에 따라 달라지는 결말, 모든 엔딩이 비극으로 끝나는 독특한 구조
&nbsp;

## 게임 시연 영상 
![play](https://github.com/user-attachments/assets/0bef8f63-c833-4824-a63a-b874ac320d38)
&nbsp;

## 구현 기능 
- (게임 시작 화면)
간단한 소개와 할 수 있는 행동을 알려줍니다. 
<img width="1191" height="703" alt="title" src="https://github.com/user-attachments/assets/f3e46123-8a42-4ce9-99fa-2b5141951ba0" />
&nbsp;

- (상태 보기)
캐릭터의 정보를 표시합니다. 
<img width="852" height="450" alt="status" src="https://github.com/user-attachments/assets/1cf1bb56-1b2d-4619-9b7b-07bd12c5714d" />
&nbsp;

- (전투 시작)
전투가 시작되면 1~4마리 교도관이 랜덤으로 등장합니다. (예시에서는 3명이 등장했습니다)
<img width="1207" height="663" alt="battle" src="https://github.com/user-attachments/assets/48ef8e28-8a68-4c3c-9314-2e75405da45a" />
&nbsp;

- (플레이어 공격)
플레이어가 공격을 선택하면 교도관 앞에 숫자가 표시되고, 공격할 수 있습니다.
<img width="1205" height="703" alt="player attack" src="https://github.com/user-attachments/assets/94fd7e4b-8e2c-4fe3-abb3-4548230ee0f1" />
&nbsp;

이미 죽은 교도관을 선택하거나, 없는 숫자를 입력하면 "잘못된 입력입니다"를 출력합니다. 

&nbsp;

공격력은 다음과 같이 오차를 가집니다. 
(기본 공격력 - 기본 공격력의 10%) ~ (기본 공격력 + 기본 공격력의 10%)
&nbsp;
죽은 몬스터는 Dead로 표시하고, 텍스트는 어두운 색으로 표시합니다.
&nbsp;



&nbsp;

- (적 공격) 
플레이어의 공격이 끝나면, 교도관이 공격합니다.
<img width="1203" height="727" alt="enemy attack" src="https://github.com/user-attachments/assets/c24bedee-c4e4-42c9-85c9-8cebdb5bc2c2" />
&nbsp;

다음을 입력하면 다음 교도관이 차례대로 공격합니다.

&nbsp;
몬스터 차례가 끝나면, 플레이어의 턴으로 돌아옵니다. 

&nbsp;

- (전투 결과)
모든 교도관이 Dead 상태가 되면 승리, 플레이어가 Dead 상태가 되면 패배하게 됩니다. 
<img width="1130" height="702" alt="win" src="https://github.com/user-attachments/assets/42d17575-a0a2-42b4-a2cb-28a68a76141a" />
<img width="880" height="693" alt="lose" src="https://github.com/user-attachments/assets/ebce9475-35ab-4387-a7bd-90552732619e" />
&nbsp;


## 핵심 기능 - 싱글톤 클래스   
<img width="1110" height="622" alt="singleton" src="https://github.com/user-attachments/assets/48dea3c5-42c9-479c-a880-4a3df6462e34" />

   
## 핵심 기능 - 리소스 관리 클래스 
<img width="1107" height="618" alt="management class" src="https://github.com/user-attachments/assets/3c729962-9515-482c-a52e-c6b782eb4519" />


## 트러블 슈팅
<img width="1110" height="621" alt="trouble shooting1-1" src="https://github.com/user-attachments/assets/11abc978-c0b5-4682-8327-d26bbd750bea" />
<img width="1111" height="622" alt="trouble shooting1-2" src="https://github.com/user-attachments/assets/aebdd0ea-c7ea-425b-8c02-846597bf8269" />
<img width="1112" height="618" alt="trouble shooting2" src="https://github.com/user-attachments/assets/2691e187-8dd4-49e3-bb54-270100ec16f4" />


## 프로젝트 회고
<img width="1111" height="622" alt="project " src="https://github.com/user-attachments/assets/ce243454-8fe1-4653-8947-ee4c8082a952" />

