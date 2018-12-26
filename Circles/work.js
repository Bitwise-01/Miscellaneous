"use strict";

/* 
 *
 * Date: 12/26/2018
 * Author: Mohamed
 * Description: Circles Magic
 * GitHub: https://github.com/Pure-L0G1C
 * 
 */

const circles = [];
const maxSpeed = 2;
const maxRange = 50;
const maxRadius = 30;
const MaxCircles = 500;
const mouse = { x: null, y: null };
const colors = [ "#A9AEC0", "#586480", "#1E1A34", "#F59B14", "#1D1933" ];

// canvas
const canvas = document.querySelector("canvas");
const context = canvas.getContext("2d");

class Circle {

    constructor(radius, color) {
        this.color = color;
        this.radius = radius;
        this.minRadius = radius;
        this.dx = (Math.random() - 0.5) * maxSpeed;
        this.dy = (Math.random() - 0.5) * maxSpeed;
        this.y =  Math.random() * (innerHeight - radius * 2) + radius;
        this.x =  Math.random() * (innerWidth - radius * 2) + radius ;
    }

    draw() {
        context.beginPath();
        context.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false);
        context.fillStyle = this.color;
        context.fill();

        // inflate and deflate
        if ((Math.abs(mouse.x - this.x) < maxRange) && (Math.abs(mouse.y - this.y) < maxRange)) {
            if (this.radius < maxRadius) {
                this.radius += 1;
            }
        } else {
            if (this.radius > this.minRadius) {
                this.radius -= 0.5;
            }
        }

        this.update();
    }

    update() {        
        // left & right
        if (((this.x + this.radius) > innerWidth) || ((this.x - this.radius) < 0)) {
            this.dx = -this.dx;
        } 

        // up & down 
        if (((this.y + this.radius) > innerHeight) || ((this.y - this.radius) < 0)) {
            this.dy = -this.dy;
        }
        
        // update positions
        this.x += this.dx;
        this.y += this.dy;
    }
}

// when the page finishes loading
window.onload = main();

function main() {
    resizeCanvas();
    createCircles();
    setEventListeners();
    animatedArc();
}

function resizeCanvas() {
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;   
}

function createCircles() {
    for (let n=0; n<MaxCircles; n++) {
        circles[n] = new Circle( (Math.random() * 5) + 1, colors[(Math.random() * colors.length).toFixed(0)])
    }
}

function setEventListeners() {

    // mouse near circle
    document.addEventListener("mousemove", function(e) {
        mouse.x = e.x;  
        mouse.y = e.y;
    });

    // window resize
    window.addEventListener("resize", function() {
        resizeCanvas();
        createCircles();
    });
}

function animatedArc() {    
    requestAnimationFrame(animatedArc)
    context.clearRect(0, 0, innerWidth, innerHeight);

    for(let n = 0; n < circles.length; n++) {
        circles[n].draw();
    }
}