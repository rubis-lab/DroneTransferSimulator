/**
 * brief	block consisting path
 * details	fundamental block which inputs direction and speed and outputs time
 * author	lucetre
 * date		20170721
 */
class Block {
private:
	char inFace, outFace;
	int inVelocity, outVelocity;
	double time;

public:
	Block() = default;
	Block(char _inFace, char _outFace) : inFace(_inFace), outFace(_outFace) {}

};