# 지하철 최단 시간 경로 찾기
최단 시간 경로와 총 소요 시간을 계산하는 콘솔 프로그램 구현

## 프로젝트 설명
- PathFinder: dijkstra 알고리즘을 활용하여 최단 경로를 계산하고 출력하는 클래스
- Subway: 지하철 역과 노선 정보를 담는 클래스
- CSVReader: CSV파일의 정보를 추출하여 Subway에 담기 위해 설계된 클래스

## 개발 환경
사용 언어: C#
OS: macOS
IDE: Visual Studio Code
.NET SDK: 10.0

## 노선 정보 데이터
### subway-info.csv
- 지하철 노선 정보(호선, 출발역, 도착역, 소요시간(초))를 담은 CSV 파일을 사용 
- 파일 경로는 Constants.cs에서 변경 가능

## 실행 방법
```bash
dotnet build
dotnet run
```
