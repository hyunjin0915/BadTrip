<img width="242" alt="Image" src="https://github.com/user-attachments/assets/a82c884a-c40c-4572-b05c-745460edbc58" />

🔗Check out our project at    [<img src="https://img.shields.io/badge/Notion-000000?style=flat-round&logo=Notion&logoColor=white"/>](https://www.notion.so/BadTrip-348552c31b654c77a426a877ab597763)


### 🎓서울여자대학교 디지털미디어학과 졸업작품 [2024.04 ~ 2024.11]  

## 사용 기술 | Technologies Used
![](https://img.shields.io/badge/unity-%23000000.svg?logo=unity&logoColor=white)
![](https://img.shields.io/badge/-C%23-000000?logo=Csharp&style=flat) <br>
<img width="5%" src="https://techstack-generator.vercel.app/github-icon.svg"/>
<br> </br>
## 프로젝트 소개 | Project Introduction

### 2D 픽셀 그래픽 스토리텔링형 시리어스 게임

청소년 마약 범죄의 심각성, 위험성을 알리고

마약 중독에 대한 경각심을 고취시키는 것이 목표인 **스토리텔링형 시리어스 게임** 콘텐츠

### 다양한 미니게임들

6가지의 미니게임들을 통해 게임성 추가
<br> </br>

## 클라이언트 개발을 맡은 파트 | Role
✔️ 클라이언트 개발 공동 작업 ✔️ 미니게임 5가지

### [미니게임 제작]

#### 1️⃣ MethBug
![Image](https://github.com/user-attachments/assets/72341681-97ac-4fdb-b2ca-0e0a72df0aa3) <br> </br>
- 구조도 
<img width="693" alt="Image" src="https://github.com/user-attachments/assets/ca9c4136-724a-4d1e-ab73-045fdc9640ee" />

#### 2️⃣ BadTrip 
![Image](https://github.com/user-attachments/assets/dabca823-40af-4e1b-bfcd-29666b49a60d)
- 구조도
<img width="806" alt="Image" src="https://github.com/user-attachments/assets/9458d8bf-7ea6-4903-9f55-0d1396b1ca65" />

#### 3️⃣ Dream
*Level 1*  
![Image](https://github.com/user-attachments/assets/63635d86-fdd3-40e3-a9d8-778b27fab53c) <br> </br>
*Level 2*  
![Image](https://github.com/user-attachments/assets/84e7089c-6edf-4400-b687-1d35d0d2a6f2) 
- 몬스터 좌우로 반복이동
- 일정 범위 내로 플레이어 진입 시 플레이어 향해 이동
- 플레이어는 밟아서 몬스터 제거 가능
- 아이템(획득 시 n초간 무적 상태) 구현 <br> </br>
*Level 3*  
![Image](https://github.com/user-attachments/assets/8d10b656-347f-4f08-a579-59eab23701c2)
- Level 3에 들어오면 몬스터들 스폰
- 스폰된 후에 플레이어를 향해 걸어오도록 구현
- 장애물(체력 감소) 및 아이템(대쉬 기능) 구현

#### 4️⃣ 퍼즐게임
![Image](https://github.com/user-attachments/assets/96e9bf91-ddbe-4ad6-9f97-249199a954f3)
- 흩어진 퍼즐들을 알맞은 위치에 배치
- 정답 위치 근처로 드래그 시 정위치로 퍼즐 조각 스내핑
- 전체 퍼즐 맞추기 성공 시 게임 종료 및 씬 전환

#### 5️⃣ 순서 맞추기
![Image](https://github.com/user-attachments/assets/65acf84a-2680-43df-bfe8-c68bba49603d)
- 규칙을 찾아 뉴런 세포들을 알맞은 순서대로 배치
- 전체 순서를 맞춘 경우 게임 클리어

### [그래픽 및 연출]
![Image](https://github.com/user-attachments/assets/a3d09925-b077-4562-b190-451536267894)
- URP Lighting과 Cinemachine을 통한 연출
- Parallax Background 구현 

### [ScriptableObject와 이벤트 구조 사용한 구조 개선]
**ScriptableObject를 중간 채널 역할로 사용하는 이벤트 구조**  
코드를 모듈화하여 계속 모니터링 하지 않아도 상태 변경에 대응 가능
- 관련 Event Action을 호출하는 **이벤트 중계기** 역할
- 다양한 채널의 기능을 논리적으로 정렬, 세분화하여 정리 및 유지 가능
- Manager 클래스와 GameObject가 **서로 다른 씬에 존재**할 수 있음

### [Scene Management]
**비동기 방식 & Additive Scene 모드 사용**  
- 전반적인 성능 개선 및 기능 별로 씬을 나누어 개발과 협업이 용이
- 메모리의 효율적 사용 및 관리 용이










