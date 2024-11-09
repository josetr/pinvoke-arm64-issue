#include <cinttypes>

struct Pod16
{
  unsigned a;
  intptr_t b;
};

struct NonPod16
{
  unsigned a;
  intptr_t b;
  ~NonPod16() {}
};

Pod16 CreatePOD(intptr_t b)
{
  Pod16 s16;
  s16.a = 1111;
  s16.b = b;
  return s16;
}

NonPod16 CreateNonPod(intptr_t b)
{
  NonPod16 s16;
  s16.a = 1111;
  s16.b = b;
  return s16;
}
