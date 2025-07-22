<div align="center">
<h2> 🎮 Text RPG 프로젝트 🎮 </h2>
<img width="1197" height="437" alt="image" src="https://github.com/user-attachments/assets/da4984e3-2efd-47b3-9c19-7ea25e314892" />
여러분은 돌이킬 수 없는 운명 앞에서 어떤 선택을 하시겠습니까? <br>
<b>'Without Her'</b>는 한 남자의 절박한 선택과 그로 인한 비극적 여정을 다룬 스토리입니다. 주인공은 우발적인 사고로 감옥에 수감된 평범한 남자입니다.
<br>
절망적인 나날을 보내던 어느 날, 아내가 교통사고로 생명이 위독하다는 청천벽력 같은 소식을 듣게 됩니다.
아내의 마지막을 함께하기 위해, 그는 탈옥수가 되기로 결심합니다. 플레이어는 주인공이 되어, 사랑하는 사람에게 닿기 위한 필사적인 탈출을 이끌게 됩니다.
</div>

## 목차
  - [개요](#개요) 
  - [게임 설명](#게임-설명)
  - [게임 플레이 방식](#게임-플레이-방식)
  - [게임 시연](#게임-시연)
  - [구현 기능](#구현-기능)
  - [핵심 기능](#핵심-기능)
  - [트러블 슈팅](#트러블-슈팅)
  - [프로젝트 회고](#프로젝트-회고)

<br>

## 개요
한 남자의 절박한 선택과 그로 인한 비극적 여정을 다룬 게임
- 게임 이름: Without Her
- 장르 : 텍스트 기반 RPG
- 컨셉 : 선과 악의 경계에서 고뇌하는 한 남자의 감옥 탈출기
- 특징 : 선택에 따라 달라지는 결말, 모든 엔딩이 비극으로 끝나는 독특한 구조
- 프로젝트 기간: 2025.07.14 - 2025.07.21
- 개발 언어: C#
- 팀원: 주슬기(기획), 이창목(기획), 정세윤(개발), 이승율(개발), 조경표(개발)

<br>

## 게임 설명
|![image](https://github.com/user-attachments/assets/f3e46123-8a42-4ce9-99fa-2b5141951ba0)|
|:---:|
|시작 화면|

|![image](https://github.com/user-attachments/assets/42d17575-a0a2-42b4-a2cb-28a68a76141a)|![image](https://github.com/user-attachments/assets/ebce9475-35ab-4387-a7bd-90552732619e)|
|:---:|:---:|
|승리 화면|패배 화면|


<b>'Without Her'</b>는 텍스트 기반의 RPG 장르입니다. 플레이어의 선택에 따라 스토리가 진행되고, 다른 결말을 만들어냅니다.

저희 게임의 핵심적인 특징은 모든 엔딩이 결국 비극으로 귀결된다는 점입니다. 탈출에 성공하면 아내의 임종을 지킬 수 있고, 실패하면 차가운 유골함을 마주하게 됩니다. 어떤 선택을 하더라도 완전한 해피엔딩은 없으며, 이를 통해 '최선'이 아닌 '차악'을 선택해야 하는 딜레마를 경험하게 됩니다.

<br>

## 게임 플레이 방식
- (조작법)
  <p>원하는 선택지를 고르면서 게임을 합니다. </p>

<br>

## 게임 시연
![1](https://github.com/user-attachments/assets/bb6ad21f-7842-47ad-95c1-b70a5fa0d9bf)
![2](https://github.com/user-attachments/assets/4fd1e0f1-cac7-4819-80ff-e0a817aa14db)
![3](https://github.com/user-attachments/assets/8a9303da-dd0d-4cb3-b7ba-9313c8ea1f09)
![4](https://github.com/user-attachments/assets/512410c0-1337-4f43-a539-f3486017f8de)
![5](https://github.com/user-attachments/assets/a47e7065-339e-4be6-a078-c08237422bda)

<br>

## 구현 기능
(게임 시작 화면)
<p>간단한 소개와 할 수 있는 행동을 알려줍니다.</p>
<img width="1191" height="703" alt="title" src="https://github.com/user-attachments/assets/f3e46123-8a42-4ce9-99fa-2b5141951ba0" />

<br>
(상태 보기)
<p>캐릭터의 정보를 표시합니다.</p>
<img width="852" height="450" alt="status" src="https://github.com/user-attachments/assets/1cf1bb56-1b2d-4619-9b7b-07bd12c5714d" />

<br>
<br>
(전투 시작)<br>
<p>전투가 시작되면 1~4마리 교도관이 랜덤으로 등장합니다. (예시에서는 3명이 등장했습니다)</p>
<img width="1207" height="663" alt="battle" src="https://github.com/user-attachments/assets/48ef8e28-8a68-4c3c-9314-2e75405da45a" />
&nbsp;

(플레이어 공격)
<p>플레이어가 공격을 선택하면 교도관 앞에 숫자가 표시되고, 공격할 수 있습니다.</p>
<img width="1205" height="703" alt="player attack" src="https://github.com/user-attachments/assets/94fd7e4b-8e2c-4fe3-abb3-4548230ee0f1" />
&nbsp;

<p>이미 죽은 교도관을 선택하거나, 없는 숫자를 입력하면 "잘못된 입력입니다"를 출력합니다.</p>
<img width="1207" height="672" alt="input error" src="https://github.com/user-attachments/assets/72a58d6f-20f4-4a96-973d-cdfd3b78f100" />
&nbsp;

<p>공격력은 다음과 같이 오차를 가집니다.</p>
<p>(기본 공격력 - 기본 공격력의 10%) ~ (기본 공격력 + 기본 공격력의 10%)</p>
<img width="852" height="450" alt="status" src="https://github.com/user-attachments/assets/1cf1bb56-1b2d-4619-9b7b-07bd12c5714d" />
<img width="1206" height="677" alt="attackVariance" src="https://github.com/user-attachments/assets/ea30fe00-1804-4f5d-8bd2-c605b0802179" />
&nbsp;

<p>죽은 몬스터는 Dead로 표시하고, 텍스트는 어두운 색으로 표시합니다.</p>
<img width="1211" height="740" alt="enemy dead" src="https://github.com/user-attachments/assets/d86d0ae8-b3fd-4da3-9cab-57928024ab76" />
&nbsp;

(적 공격)
</p>플레이어의 공격이 끝나면, 교도관이 공격합니다.</p>
<img width="1203" height="727" alt="enemy attack" src="https://github.com/user-attachments/assets/c24bedee-c4e4-42c9-85c9-8cebdb5bc2c2" />
&nbsp;

<p>다음을 입력하면 다음 교도관이 차례대로 공격합니다.</p>
<img width="1205" height="708" alt="enemy turn1" src="https://github.com/user-attachments/assets/bfbb4420-d347-4c01-9dfa-c6d42e23e147" />
<img width="1206" height="721" alt="enemy turn2" src="https://github.com/user-attachments/assets/d03149ae-24d8-4e82-87c3-b1a182550f60" />
&nbsp;

<p>몬스터 차례가 끝나면, 플레이어의 턴으로 돌아옵니다.</p>
<img width="1208" height="788" alt="player turn" src="https://github.com/user-attachments/assets/2fd00e1e-5ec3-44e2-b93f-f430e03e9fe4" />
&nbsp;

(전투 결과)
<p>모든 교도관이 Dead 상태가 되면 승리, 플레이어가 Dead 상태가 되면 패배하게 됩니다.</p>
<img width="1130" height="702" alt="win" src="https://github.com/user-attachments/assets/42d17575-a0a2-42b4-a2cb-28a68a76141a" />
<img width="880" height="693" alt="lose" src="https://github.com/user-attachments/assets/ebce9475-35ab-4387-a7bd-90552732619e" />
&nbsp;


## 핵심 기능
<img width="1110" height="622" alt="singleton" src="https://github.com/user-attachments/assets/48dea3c5-42c9-479c-a880-4a3df6462e34" />
<img width="1107" height="618" alt="management class" src="https://github.com/user-attachments/assets/3c729962-9515-482c-a52e-c6b782eb4519" />

<br><br>

## 트러블 슈팅
<img width="1110" height="621" alt="trouble shooting1-1" src="https://github.com/user-attachments/assets/11abc978-c0b5-4682-8327-d26bbd750bea" />
<img width="1111" height="622" alt="trouble shooting1-2" src="https://github.com/user-attachments/assets/aebdd0ea-c7ea-425b-8c02-846597bf8269" />

<br><br>

## 프로젝트 회고 
<img width="1111" height="622" alt="project " src="https://github.com/user-attachments/assets/ce243454-8fe1-4653-8947-ee4c8082a952" />
