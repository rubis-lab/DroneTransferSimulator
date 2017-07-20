
// Block consisting path
class Block {
private:
	char inFace, outFace;
	int velocity;
	double time;

public:
	Block() = default;
	Block(char _inFace, char _outFace) : inFace(_inFace), outFace(_outFace) {}

};