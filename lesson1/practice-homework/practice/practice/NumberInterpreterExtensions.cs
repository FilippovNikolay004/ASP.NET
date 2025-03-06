namespace RequestProcessingPipeline {
    public static class NumberInterpreterExtensions {
        public static IApplicationBuilder UseFromTwentyToHundred(this IApplicationBuilder builder) {
            return builder.UseMiddleware<NumberInterpreterMiddleware>();
        }
    }
}
