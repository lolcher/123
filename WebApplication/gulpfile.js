/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var ts = require('gulp-typescript');
var tsProject = ts.createProject('tsconfig.json');

var config = {
    html: ['app/*.html', 'app/**/*.html'],
    vendor: [
        'node_modules/knockout/build/output/knockout-latest.js',
        'node_modules/jquery/dist/jquery.min.js',
        'node_modules/requirejs/require.js'
    ]
}

gulp.task('vendor',
    function () {
        return gulp.src(config.vendor)
            .pipe(gulp.dest("build/vendor/"));
    });

gulp.task('html',
    function() {
        return gulp.src(config.html)
            .pipe(gulp.dest("build/"));
    });

gulp.task('build', ['html', 'vendor'],
    function() {
        return tsProject.src()
            .pipe(tsProject())
            .js
            .pipe(gulp.dest("build"));
    });

gulp.task('default',
    ['build'],
    function() {
    });