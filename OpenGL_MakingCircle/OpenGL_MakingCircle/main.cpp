#include<gl/glut.h>
#include<glm/glm.hpp>

void myDisplay()
{
	//window창의 바탕색 - 검정색으로 만듦.
	glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

	//어떤 버퍼를 지울 것인지 결정 - 색상버퍼를 지움.
	//색상버퍼 : 실제 모니터에 출력할 크기만큼 픽셀을 갖고 있는 버퍼
	glClear(GL_COLOR_BUFFER_BIT);

	//선 색깔
	glColor3f(1.0f, 0.0f, 0.0f);

	//반지름 설정
	double rad = 1;

	//선분 그리기 - GL_LINE_STRIP : 선분의 마지막 점이 제일 처음 시작점과 연결되지 않는다.
	glBegin(GL_LINE_LOOP);


	for (int i = 0; i < 360; i++)
	{
		double angle, x, y;

		//라디안으로 바꿔 계산해야하기 때문에
		angle = i * 3.141592 / 180;
		x = rad * cos(angle);
		y = rad * sin(angle);
		glVertex2f(x, y);
	}


	glEnd();

	//명령이 다 수행되지 않는 상태에서 return될 수 있음 - 속도 측면에서 유리
	glFlush();
}

int main(int argc, char* argv[])
{
	//GLUT라이브러리 초기화
	glutInit(&argc, argv);

	//width, height 값이 500 생성
	glutInitWindowSize(500, 500);

	//window 이름 설정
	glutCreateWindow("3D Programming_Making Circle");

	//화면 그릴 때 함수 호출
	glutDisplayFunc(myDisplay);

	//계속 함수 실행하면서 발생하는 메세지를 받아 처리함.
	glutMainLoop();
	return 0;
}