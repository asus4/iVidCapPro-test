#import "DisplayManager.h"

extern "C" EAGLContext* ivcp_UnityGetContext()
{
	return UnityGetMainScreenContextGLES();
}
