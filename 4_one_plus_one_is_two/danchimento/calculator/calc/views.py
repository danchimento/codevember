from django.shortcuts import render

# Create your views here.
from django.http import HttpResponse


def index(request):
    return render(request, "index.html", {})

def add(request):
    num1 = int(request.GET.get('num1', ''))
    num2 = int(request.GET.get('num2', ''))

    return HttpResponse(num1 + num2)

def sub(request):
    num1 = int(request.GET.get('num1', ''))
    num2 = int(request.GET.get('num2', ''))

    return HttpResponse(num1 - num2)